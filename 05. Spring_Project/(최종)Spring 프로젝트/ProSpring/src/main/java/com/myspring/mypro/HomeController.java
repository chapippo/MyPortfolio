package com.myspring.mypro;

import java.util.List;
import java.util.Map;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;

import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;

import org.springframework.web.servlet.ModelAndView;

import com.myspring.covid.CovidServiceImpl;


@Controller
public class HomeController {
	@Autowired
	CovidServiceImpl covidService;
	
	// 메인 페이지 화면
	@RequestMapping(value="/", method = RequestMethod.GET)
	public ModelAndView home() {
		ModelAndView Home = new ModelAndView("/home");
		List<Map<String, Object>> list = this.covidService.list();
		Home.addObject("data", list);
		return Home;
	}
	
}
