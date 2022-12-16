<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="core" %>
<%@ taglib prefix="fmt" uri="http://java.sun.com/jsp/jstl/fmt" %>
<%@ taglib uri="http://java.sun.com/jsp/jstl/functions" prefix="fn" %>
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>공지사항 상세</title>
</head>
<body>
	<jsp:include page="/WEB-INF/views/include/header.jsp"></jsp:include>
	<form action="notice_delete" id="notice_del" method="post" style="display:none;">
		<input type="text" name="bno" value="${data.bno }"/>
	</form>
	<form action="notice_modify" id="notice_modi" style="display:none;">
		<input type="text" name="bno" value="${data.bno }"/>
		<input type="text" name="title" value="${data.title }"/>
		<input type="text" name="content" value="${data.content }"/>
	</form>
	
	<h2>공지 안내</h2>
	<table>
		<tr>
			<th class="w-px160">제목</th>
			<td colspan="5" class="left">${data.title }</td>
		</tr>
		<tr>
			<th>글 번호</th>
			<td>${data.bno}</td>
			<th>작성일자</th>
			<td><fmt:formatDate value="${data.bdate}" pattern="yyyy-MM-dd" type="date"/></td>
			<th>조회수</th>
			<td>${data.bHit}</td>
		</tr>
		<tr>
		<%
			pageContext.setAttribute("crcn", "\r\n");
			pageContext.setAttribute("br", "<br/>");
		%>
			<td colspan="6" class="left">${fn:replace(data.content, crcn, br) }</td>
		</tr>
			
	</table>
	
	
	<div class="btnSet">
		<!-- 관리자인 경우 수정/삭제 가능 -->
		<core:if test="${login_info.id eq 'admin' }">
			<a class="btn-fill" onclick="go_modify()">수정</a>
			<a class="btn-fill" onclick="if(confirm('정말 삭제하시겠습니까?'))go_delete()">삭제</a>
		</core:if>
		<a class="btn-empty" onclick="history.go(-1)">돌아가기</a>
	</div>
	

	<script type="text/javascript">
		function go_delete() {
			alert("공지삭제완료!");
			$('#notice_del').submit();
		}
		
		function go_modify() {
			$('#notice_modi').submit();
		}
	</script>
</body>
</html>