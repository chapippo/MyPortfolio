<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<%@ taglib prefix="core" uri="http://java.sun.com/jsp/jstl/core" %>
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>의료진 리스트 페이지</title>
</head>
<body>
	<jsp:include page="/WEB-INF/views/include/header.jsp"></jsp:include>
	<div id="content">
		<h2 id="s" style="display:none;">${m_code}</h2>
		<h2 id="t"></h2>
		<table class='w-pct60'>
			<tr>
				<th class='w-px60'>이름</th>
				<th class='w-px60'>성별</th>
				<th class='w-px60'>전공</th>
				<th class='w-px60'>직급</th>
				<th class='w-px140'>이메일</th>
				<th class='w-px120'>전화번호</th>
			</tr>
			<core:forEach var="dto" items="${data}">
				<tr>
					<td>${dto.name}</td>
					<td>${dto.gender}</td>
					<td>${dto.m_code}</td>
					<td>${dto.jpo_code}</td>
					<td>${dto.email}</td>
					<td>${dto.phone}</td>
				</tr>
			</core:forEach>
		</table>
	</div>
	
	
	
	<script>
		let str = $('#s').text();
		console.log(str);
		
		switch(str){
			case "01":
				str = str.replace('01', '내과');
				document.getElementById("t").innerHTML = str;
				break;
			case "05":
				str = str.replace('05', '정형외과');
				document.getElementById("t").innerHTML = str;
				break;
			case "12":
				str = str.replace('12', '안과');
				document.getElementById("t").innerHTML = str;
				break;
			case "13":
				str = str.replace('13', '이비인후과');
				document.getElementById("t").innerHTML = str;
				break;
			case "49":
				str = str.replace('49', '치과');
				document.getElementById("t").innerHTML = str;
				break;
		}
	</script>
</body>
</html>