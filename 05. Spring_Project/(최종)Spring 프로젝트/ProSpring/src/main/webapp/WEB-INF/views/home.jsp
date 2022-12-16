<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>홈페이지</title>
</head>
<body>
	<jsp:include page="/WEB-INF/views/include/header.jsp"></jsp:include>
	<div id="content">
		<h1>10월 코로나 확진자 수</h1>
		<jsp:include page="/WEB-INF/views/CovidD3Chart.jsp"></jsp:include>
	</div>
</body>
</html>