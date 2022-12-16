package com.myspring.covid;

import java.util.List;
import java.util.Map;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

//Controller�� DAO�� �̾���
@Service
public class CovidServiceImpl implements CovidService {

	@Autowired
	CovidDao covidDao;	//��ü �ڵ� ���� �� ����
	
	@Override
	public List<Map<String, Object>> list() {
		return this.covidDao.selectList(null);
	}
}
