<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core"%>
<c:set var="path" value="${pageContext.request.contextPath}"/>
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>공지 작성</title>
<script type="text/javascript" src="${path}/resources/js/need_check.js?v=<%=new java.util.Date().getTime() %>"></script>
</head>
<body>
	<jsp:include page="/WEB-INF/views/include/header.jsp"></jsp:include>
	<h2>공지 작성</h2>
	<form action="notice_create" method="post">
		<table>
			<tr>
				<th class="w-px160">제목</th>
				<td><input type="text" name="title" class="need"/></td>
			</tr>
			<tr>
				<th>내용</th>
				<td><textarea name="content" class="need"></textarea></td>
			</tr>
		</table>	
	</form>
	
	<div class="btnSet">
		<a class="btn-fill" onclick="if(necessary()) $('form').submit()">저장</a>
		<a class="btn-empty" href="list.board">취소</a>
	</div>
</body>
</html>