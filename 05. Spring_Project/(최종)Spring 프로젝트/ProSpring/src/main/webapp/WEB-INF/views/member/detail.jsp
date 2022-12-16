<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>회원정보 상세 페이지</title>
</head>
<body>
	<jsp:include page="/WEB-INF/views/include/header.jsp"></jsp:include>
	
	<form action="delete" id="del" method="post" style="display:none;">
		<input type="text" name="id" value="${data.id }"/>
	</form>
	<form action="modify" id="modi" style="display:none;">
		<input type="text" name="id" value="${data.id }"/>
		<input type="text" name="phone" value="${data.phone }"/>
		<input type="text" name="addr" value="${data.addr }"/>
	</form>
	
	<div id="content">
		<h3>[${data.name}] 님의 상세 정보</h3>
		<table class='w-pct60' id="table_id">
			<tr>
				<th class="w-px160">이름</th>
				<td>${data.name }</td>
			</tr>
			<tr>
				<th class="w-px160">ID</th>
				<td>${data.id }</td>
			</tr>
			<tr>
				<th class="w-px160">성별</th>
				<td>${data.gender }</td>
			</tr>
			<tr>
				<th class="w-px160">이메일</th>
				<td>${data.email }</td>
			</tr>
			<tr>
				<th class="w-px160">전화번호</th>
				<td>${data.phone }</td>
			</tr>
			<tr>
				<th class="w-px160">생년월일</th>
				<td>${data.birth }</td>
			</tr>
			<tr>
				<th class="w-px160">주소</th>
				<td>(${data.post})${data.addr }</td>
			</tr>
			<tr>
				<th class="w-px160">직업</th>
				<td id="pt_code">${data.pt_code }</td>
			</tr>
			<tr id="m_code">
				<th class="w-px160">전공</th>
				<td>${data.m_code }</td>
			</tr>
			<tr id="jpo_code">
				<th class="w-px160">직급</th>
				<td>${data.jpo_code }</td>
			</tr>	
		</table>
	</div>
	
	<div class="btnSet">
		<a class="btn-fill" onclick="go_modify()">수정</a>
		<a class="btn-fill" onclick="if(confirm('정말 탈퇴하시겠습니까?'))go_delete()">회원탈퇴</a>
		<a class="btn-empty" onclick="history.go(-1)">돌아가기</a>
	</div>
	

	
	<script type="text/javascript">
		let ptCode = document.getElementById("pt_code").innerText;
		if(ptCode == "환자" || ptCode == "관리자"){
			document.getElementById("m_code").style.display = 'none';
			document.getElementById("jpo_code").style.display = 'none';
		}
		
		function go_delete() {
			alert("회원탈퇴완료!");
			$('#del').submit();
		}
		
		function go_modify() {
			$('#modi').submit();
		}
		
	</script>
</body>
</html>