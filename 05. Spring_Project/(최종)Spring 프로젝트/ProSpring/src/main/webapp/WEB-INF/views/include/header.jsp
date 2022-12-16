<%@ page language="java" contentType="text/html; charset=UTF-8" pageEncoding="UTF-8"%>
<%@ taglib prefix="core" uri="http://java.sun.com/jsp/jstl/core" %>

<link rel="stylesheet" type="text/css" href="css/common.css?v=<%=new java.util.Date().getTime() %>">

<script type="text/javascript" src="https://code.jquery.com/jquery-3.5.1.min.js"></script>

<style>
header ul, header ul li {
	margin: 0;
	padding: 0;
	display: inline;
}

header .category {
	font-size: 18px;
}

header .category ul li:not(:first-child) { /* 첫번째 li만 빼고 지정 */
	padding-left: 30px;
}

header .category ul li a:hover, header .category ul li a.active {
	font-weight: bold;
	color: #0000cd;
}

header #userid, header #userpw {
	width: 100px;
	height: 18px;
	font-size: 14px;
}

header ul li input { display:block; }

a:hover{color:blue;}
a{font-weight:bold;}
</style>
<header style="border-bottom: 1px solid #ccc; padding: 15px 0; text-align: left">
	<div class="category" style="margin-left: 100px;"> 
		<ul>
			<li><a href="/"><img src="/img/logo2.png" /></a></li>
			<li><a href="list.staff" >의료진</a></li>
			<li><a href="list.board" >공지사항</a></li>
		</ul>
	</div>
	
	<div style="position: absolute; right: 0; top: 25px; margin-right: 100px;">
		<!-- 로그인한 경우 -->
		<core:if test="${!empty login_info }">
			<ul>
				<li><a href="detail?id=${login_info.id}">${login_info.name }</a>님 반갑습니다.</li>
				<li><a class="btn-fill" onclick="go_logout()">로그아웃</a></li>
			</ul>
		</core:if>

		 <!-- 로그인하지 않은 경우 -->
		 <core:if test="${empty login_info }">
			 <ul>
			 	<li>
			 		<span style="position: absolute; top: -14px; left: -120px">
						<input type="text" id="userid" placeholder="아이디" />
						<input type="password" onkeypress="if(event.keyCode == 13) {go_login()}" id="userpw" placeholder="비밀번호" />
			 		</span>
			 	</li>
			 	<li><a class="btn-fill" onclick="go_login()">로그인</a></li>
			 	<li><a class="btn-fill" href="member">회원가입</a></li>
			 </ul>
		 </core:if>
	</div>
</header>

<script>
function go_login() {
	if( $('#userid').val() == '' ) {
		alert('아이디를 입력하세요!');
		$('#userid').focus();
		return;
	} else if( $('#userpw').val() == '' ) {
		alert('비밀번호를 입력하세요!');
		$('#userpw').focus();
		return;
	}

	$.ajax({
		type: 'post',
		url: 'login',
		data: { id:$('#userid').val(), pw:$('#userpw').val() },
		success: function(data) {
			if(data == 'true') {
				location.reload();
			} else {
				alert('아이디나 비밀번호가 일치하지 않습니다!');
				$("#userid").focus();
			}
		},
		error: function(req, text) {
			 alert(text + ': ' + req.status);
	 	}
	});
}

function go_logout() {
	$.ajax({
		type: "post",
		url: "logout",
		success: function() {
			location.reload();
		},
		error: function(req, text) {
			 alert(text + ': ' + req.status);
	 	}
	});
}
</script>