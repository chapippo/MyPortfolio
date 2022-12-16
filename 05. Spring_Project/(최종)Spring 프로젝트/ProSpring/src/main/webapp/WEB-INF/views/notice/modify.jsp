<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core"%>
<c:set var="path" value="${pageContext.request.contextPath}"/>
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>공지 수정</title>
<script type="text/javascript" src="${path}/resources/js/need_check.js?v=<%=new java.util.Date().getTime() %>"></script>
</head>
<body>
	<jsp:include page="/WEB-INF/views/include/header.jsp"></jsp:include>
	<h2>공지 수정</h2>

	<form action="notice_modify" method="post" id="notice_modi">
		<input type="hidden" name="bno" value="${data.bno}" />
		<table>
			<tr>
				<th class="w-px160">제목</th>
				<td><input class="need" type="text" name="title" value="${data.title }" /></td>
			</tr>
			<tr>
				<th>내용</th>
				<td><textarea class="need" name="content">${data.content }</textarea></td>
			</tr>
			
		</table>
	</form>
	
	<div class="btnSet">
		<a class="btn-fill" onclick="go_modify()">저장</a> 
		<a class="btn-empty" onclick="history.go(-1)">돌아가기</a>
	</div>

	<script type="text/javascript">
		function go_modify() {
			$('#notice_modi').submit();
		}
		
	</script>
</body>
</html>