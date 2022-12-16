package com.myspring.member;

import java.util.HashMap;
import java.util.List;
import java.util.Map;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

@Service
public class MemberServiceImpl implements MemberService{
	@Autowired
	MemberDAO dao;
	
	// ���̵� �ߺ� üũ Ȯ��
	@Override
	public boolean id_check(String id) {
		return this.dao.id_check(id);
	}
	
	// ȸ������
	@Override
	public String join(Map<String, Object> map) {
		int affectRowCount = this.dao.join(map);
		if(affectRowCount == 1) {
			return map.get("id").toString();
		}
		return null;
	}
	
	// �α���
	@Override
	public MemberDTO login(HashMap<String, String> map) {
		return this.dao.login(map);
	}
	
	// ȸ�� �� ȭ��
	@Override
	public MemberDTO detail(String id){
		return this.dao.detail(id);
	}
	
	// ȸ�� ���� ����
	@Override
	public boolean modify(Map<String, Object> map) {
		int affectRowCount = this.dao.modify(map);
		return affectRowCount == 1;
	}
	
	// ȸ�� Ż��
	@Override
	public boolean delete(String id) {
		int affectRowCount = this.dao.delete(id);
		return affectRowCount == 1;
	}
	
	// �Ƿ��� ��� ��ȸ
	@Override
	public List<MemberDTO> staff_list(String m_code) {
		return this.dao.staff_list(m_code);
	}
	
}
