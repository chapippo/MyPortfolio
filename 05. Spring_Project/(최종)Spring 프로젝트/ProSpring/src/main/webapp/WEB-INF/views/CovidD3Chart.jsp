<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>Insert title here</title>
<script src="https://d3js.org/d3.v3.min.js"></script>
<style>
svg {
	height: 500px;
	width: 1200px;
}
rect {
	fill: green;
}

</style>
</head>
<body>
	<svg id="myg"></svg>
	<script>
		let data = []
		
		<c:forEach items="${data}" var="item">
			data.push({
				name: "${item.month}",
				value: "${item.confCase}"
			})
		</c:forEach>
			
		console.log(data)
			
		
		

		 d3.select("#myg")
			.selectAll("rect")
			.data(data)
			.enter()
			.append("rect")
			.attr("x",function(d,i){return 25+i*120})
			.attr("y",function(d,i){return 320- (d.value/1000 )  } )
			.attr("height",(d,i)=>{return  (d.value/1000 )  })
			.attr("width", "25")
			.attr("value", (d)=> {return d.value})
for(let i = 0; i<data.length; i++) {
	let item = data[i]
		
		d3.select('#myg')
		.append('text')
		.attr('x', (i*120))
		.attr('y', 340)
		.attr("font-family", "D2Coding")
	    .attr("font-size", "15px")
	    .attr("fill", "black")
	    .text(item.name)
	    
	    if(i==0) {

		    d3.select('#myg')
			.append('text')
			.attr('x', 17)
			.attr('y', 315- (item.value/1000 ))
			.attr("font-family", "D2Coding")
		    .attr("font-size", "15px")
		    .attr("fill", "black")
		    .text(parseInt(item.value))
	    } else {
		    d3.select('#myg')
			.append('text')
			.attr('x', 17+i*120)
			.attr('y', 315- (item.value/1000 ))
			.attr("font-family", "D2Coding")
		    .attr("font-size", "15px")
		    .attr("fill", "black")
		    .text(parseInt(item.value))
	    }
	
}
	</script>
</body>
</html>










