<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<%@ taglib prefix="core" uri="http://java.sun.com/jsp/jstl/core" %>
<%@ taglib prefix="fmt" uri="http://java.sun.com/jsp/jstl/fmt" %>
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>공지사항</title>
</head>
<body>
	<jsp:include page="/WEB-INF/views/include/header.jsp"></jsp:include>
	<h2>공지사항</h2>
	<form action="list.board" id="list">
		<div id="list-top">
			<div>
				<ul>
					<li><input type="text" name="keyword" class="w-px300" value="${keyword}" placeholder="제목입력"/></li>
					<li><a class="btn-fill" onclick="$('#list').submit()">검색</a></li>
				</ul>
				<ul>
					<core:if test="${login_info.id eq 'admin' }">
						<li><a class="btn-fill" href="notice_write">글쓰기</a></li>
					</core:if>
				</ul>
			</div>
		</div>
	</form>

	<table>
		<tr>
			<th class="w-px60">번호</th>
			<th>제목</th>
			<th class="w-px100">작성자</th>
			<th class="w-px120">작성일자</th>
			<th class="w-px60">조회수</th>
		</tr>
		<core:forEach var="row" items="${data}">
			<tr>
				<td>${row.bno }</td>
				<td><a href="notice_detail?title=${row.title}">${row.title}</a></td>
				<td>${row.bname}</td>
				<td><fmt:formatDate value="${row.bdate}" pattern="yyyy-MM-dd" type="date"/></td>
				<td>${row.bHit}</td>
			</tr>
		</core:forEach>
	</table>
	
	<div class="text-center">
				<core:if test="${startPage!=1}">
					<a class="btn btn-outline-primary" href="/list.board?nowPage=${startPage-1}&keyword=${keyword}">이전</a>
				</core:if>
				<core:forEach var="idx" begin="${startPage}" end="${endPage}">
					<core:choose>
						<core:when test="${nowPage!=idx}">
							<a class="btn btn-warning" href="/list.board?nowPage=${idx}&keyword=${keyword}">
								${idx}</a>
						</core:when>
						<core:when test="${nowPage==idx}">
							<b class="btn btn-dark" >${idx}</b>
							<!-- 현재껀 진하게 표시 -->
						</core:when>
					</core:choose>
				</core:forEach>
				<core:if test="${endPage!=totalCount}">
					<a class="btn btn-outline-danger"  href="/list.board?nowPage=${endPage+1}&keyword=${keyword}">다음</a>
				</core:if>
			</div>
	
</body>
</html>