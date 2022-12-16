<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<%@ taglib prefix="core" uri="http://java.sun.com/jsp/jstl/core" %>
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>의료진 전공 선택 페이지</title>
</head>
<body>
	<jsp:include page="/WEB-INF/views/include/header.jsp"></jsp:include>
	<form action="list" id="list1" method="post" style="display:none;">
		<input type="text" name="m_code" value="01"/>
	</form>
	<form action="list" id="list2" method="post" style="display:none;">
		<input type="text" name="m_code" value="05"/>
	</form>
	<form action="list" id="list3" method="post" style="display:none;">
		<input type="text" name="m_code" value="12"/>
	</form>
	<form action="list" id="list4" method="post" style="display:none;">
		<input type="text" name="m_code" value="13"/>
	</form>
	<form action="list" id="list5" method="post" style="display:none;">
		<input type="text" name="m_code" value="49"/>
	</form>
	
	
	<div id="content">
		<div class="btnSet">
			<a class="btn-fill" onclick="go_select1()">내과</a>
			<a class="btn-fill" onclick="go_select2()">정형외과</a>
			<a class="btn-fill" onclick="go_select3()">안과</a>
			<a class="btn-fill" onclick="go_select4()">이비인후과</a>
			<a class="btn-fill" onclick="go_select5()">치과</a>
		</div>
	</div>
	
	<script type="text/javascript">
		
		function go_select1() {
		
			$('#list1').submit();
		}
		
		function go_select2() {
			
			$('#list2').submit();
		}
		
		function go_select3() {
			
			$('#list3').submit();
		}
		
		function go_select4() {
			
			$('#list4').submit();
		}
		
		function go_select5() {
			
			$('#list5').submit();
		}
		
	</script>
</body>
</html>