<%@ page language="java" contentType="text/html; charset=UTF-8"
	pageEncoding="UTF-8"%>
<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core"%>
<c:set var="path" value="${pageContext.request.contextPath}"/>
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>회원수정</title>
<script type="text/javascript" src="${path}/resources/js/join_check.js?v=<%=new java.util.Date().getTime()%>"></script>
<!-- 다음 우편번호 api -->
<script src="https://t1.daumcdn.net/mapjsapi/bundle/postcode/prod/postcode.v2.js"></script>
<style type="text/css">
table tr td {
	text-align: left;
}

table tr td input[name=tel] {
	width: 40px;
}

table tr td input[name=addr] {
	width: calc(100% - 14px);
}

.ui-datepicker select {
	vertical-align: middle;
	height: 28px;
}

.valid, .invalid {
	font-size: 11px;
	font-weight: bold;
}

.valid {
	color: green;
}

.invalid {
	color: red;
}
}
</style>
<link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
</head>
<body>
	<jsp:include page="/WEB-INF/views/include/header.jsp"></jsp:include>
	<h2>[${data.name}] 님의 상세 정보</h2>
	<form action='modify' method='post'>
		<table class="w-pct60">
			<tr>
				<th class="w-px160">이름</th>
				<td><input type="text" name="name" value="${data.name }" style="text-align:center"/></td>
			</tr>
			<tr>
				<th>아이디</th>
				<td><input type="text" title="아이디" name="id" class="chk" value="${data.id }" style="text-align:center" readonly/></td>
			</tr>
			<tr>
				<th>비밀번호</th>
				<td><input type="password" title="비밀번호" name="pw" class="chk" />
					<div class="valid">비밀번호를 입력하세요. (영문 대/소문자, 숫자를 모두 포함)</div></td>

			</tr>
			<tr>
				<th>비밀번호 확인</th>
				<td><input type="password" title="비밀번호 확인" name="pw_ck" class="chk" />
					<div class="valid">비밀번호를 다시 입력하세요.</div></td>
			</tr>
			<tr>
				<th>성별</th>
				<td>
					<label><input type="radio" name="gender" value="남" checked />남</label> 
					<label><input type="radio" name="gender" value="여" />여</label>
				</td>
			</tr>
			<tr>
				<th>이메일</th>
				<td><input type="text" title="이메일" name="email" class="chk" value="${data.email }" style="text-align:center"/>
					<div class="valid">이메일을 입력하세요.</div></td>
			</tr>
			<tr>
				<th>전화번호</th>
				<td>
					<input type="text" name="ph1" value="${ph1}" style="display:inline; width:18%; text-align:center; "/> - <input type="text" name="ph2" value="${ph2}" style="display:inline; width:18%; text-align:center;"/> - <input type="text" name="ph3" value="${ph3}" style="display:inline; width:18%; text-align:center;"/>
				</td>
			</tr>
			<tr>
				<th>생년월일</th>
				<td><input type="text" name="birth" readonly value="${data.birth }" style="text-align:center"/> <span 
				id="delete" style="color: red; position: relative; right: 25px; display: none;"><i 
				class="fas fa-times font-img"></i></span>
				</td>
			</tr>
			<tr>
				<th>주소</th>
				<td>
					<a class='btn-fill-s' onclick="daum_post()">우편번호 찾기</a> 
					<input type="text" name="post" class="w-px60" readonly value="${data.post }" style="text-align:center"/> 
					<input type="text" name="addr" readonly value="${addr }" /> 
					<input type="text" name="addr2" value="${addr2 }" />
				</td>
			</tr>
			<tr>
				<th>직업</th>
				<td>
					<select name="pt_code" id="pt_code" onchange="changeSelection()" >
						<option value="" selected>선택하기</option>
						<option value="001">의사</option>
						<option value="002">간호사</option>
						<option value="003">환자</option>				
					</select>
				</td>
			</tr>
			
			
			<tr id="select_staff" style=display:none;>
					<th>전공</th>
					<td>
						<select name="m_code">
							<option value="" selected>선택하기</option>
							<option value="01">내과</option>
							<option value="05">정형외과</option>
							<option value="12">안과</option>
							<option value="13">이비인후과</option>
							<option value="49">치과</option>
						</select>				
					</td>
				</tr>
				
			<tr id="select_doctor" style=display:none;>
				<th>직급(의사)</th>
				<td>
					<select name="jpo_code_d">
						<option value="" selected>선택하기</option>
						<option value="101">레지던트</option>
						<option value="102">치프</option>
						<option value="103">펠로우</option>
						<option value="104">과장</option>
						<option value="105">원장</option>
					</select>				
				</td>
			</tr>
				
			<tr id="select_nurse" style=display:none;>
				<th>직급(간호사)</th>
				<td>
					<select name="jpo_code_n">
						<option value="" selected>선택하기</option>
						<option value="201">간호사</option>
						<option value="202">수간호사</option>
						<option value="203">간호과장</option>
						<option value="204">간호부장</option>
					</select>				
				</td>				
			</tr>
		</table>
	</form>
	<div class="btnSet">
		<a class="btn-fill" onclick="go_modify()">저장</a> 
		<a class="btn-empty" onclick="history.go(-1)">돌아가기</a>
	</div>
	
	<script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
	
	<script type="text/javascript">
		function changeSelection(){
			let selectPtcode = document.getElementById("pt_code").value;
			
			if(selectPtcode == "001"){
				document.getElementById("select_staff").style.display = '';
				document.getElementById("select_doctor").style.display = '';
				document.getElementById("select_nurse").style.display = 'none';
			} else if(selectPtcode == "002"){
				document.getElementById("select_staff").style.display = '';
				document.getElementById("select_doctor").style.display = 'none';
				document.getElementById("select_nurse").style.display = '';
			} else{
				document.getElementById("select_staff").style.display = 'none';
				document.getElementById("select_doctor").style.display = 'none';
				document.getElementById("select_nurse").style.display = 'none';
			}
		}
		
		//유효성 검사
		$('.chk').on('keyup', function() {
			if ($(this).attr('name') == 'id') {
				if (event.keyCode == 13) {
					id_check();
				} else {
					$(this).removeClass('chked');
					validate($(this));
				}
			} else {
				validate($(this));
			}
		});

		function validate(t) {
			var data = join.tag_status(t);
			display_status(t.siblings('div'), data);
		}

		function display_status(div, data) {
			div.text(data.desc);
			div.removeClass();
			div.addClass(data.code)
		}

		// 만 13세 이상만 선택 가능하게 처리
		var today = new Date();
		var endDay = new Date(today.getFullYear() - 13, today.getMonth(), today
				.getDate());

		$('[name=birth]').datepicker(
				{
					dateFormat : 'yy-mm-dd',
					changeYear : true,
					changeMonth : true,
					showMonthAfterYear : true,
					dayNamesMin : [ '일', '월', '화', '수', '목', '금', '토' ],
					monthNamesShort : [ '1월', '2월', '3월', '4월', '5월', '6월',
							'7월', '8월', '9월', '10월', '11월', '12월' ],
					maxDate : endDay
				//beforeShowDay: after	//오늘 이후로 선택 못하게 하는 함수
				});

		$('[name=birth]').change(function() {
			$('#delete').css('display', 'inline-block');
		});

		$('#delete').click(function() {
			$('[name=birth]').val('');
			$('#delete').css('display', 'none');
		});

		function after(date) {
			if (date > new Date()) {
				return [ false ];
			} else {
				return [ true ];
			}
		}

		function daum_post() {
			new daum.Postcode(
					{
						oncomplete : function(data) {
							$('[name=post]').val(data.zonecode); //우편번호
							//지번 주소 : J, 도로명 주소 : R
							var address = data.userSelectedType == 'J' ? data.jibunAddress
									: data.roadAddress; //클릭한 지번주소나, 도로명주소가 저장됨
							if (data.buildingName != '') {
								address += ' (' + data.buildingName + ')'; //건물 명이 있으면 건물 명을 붙여줌
							}
							$('[name=addr]').eq(0).val(address);
						}
					}).open();
		}

		function go_modify() {
			
			$('form').submit();
		}

		
	</script>
	
</body>
</html>