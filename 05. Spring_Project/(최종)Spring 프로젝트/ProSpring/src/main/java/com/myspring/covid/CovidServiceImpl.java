package com.myspring.covid;

import java.util.List;
import java.util.Map;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

//Controller尔 DAO甫 捞绢淋
@Service
public class CovidServiceImpl implements CovidService {

	@Autowired
	CovidDao covidDao;	//按眉 磊悼 积己 棺 包府
	
	@Override
	public List<Map<String, Object>> list() {
		return this.covidDao.selectList(null);
	}
}
