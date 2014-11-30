define([],function(){

	var browserLanguage = window.navigator.userLanguage || window.navigator.language;


	var getJSONData = function(selectedLanguage){

		var jsonObject = null;
		var filePath = 'scripts/modules/' + selectedLanguage + '.json';
		var xobj = new XMLHttpRequest();


		xobj.overrideMimeType("application/json");
		xobj.open('GET',filePath,false); // Ideally should be used as true

		xobj.onreadystatechange = function() {
			if(xobj.readyState == 4 && xobj.status=="200")
			{
				jsonObject  = JSON.parse(xobj.responseText);
				
			} 
			else if(xobj.readyState == 4 && xobj.status=="404")
			{
				restoreDefLangSelection();
				jsonObject = getJSONData(browserLanguage);
			}
		};

		xobj.send(null);
		return jsonObject;
	};


	var restoreDefLangSelection = function(){

		var selectElement = document.getElementById("selectLanguage");
		var tot = selectElement.length;

		for(var i=0;i<tot;i++)
		{
			if(selectElement[i].value === browserLanguage)
			{
				selectElement.selectedIndex = i;
				break;
			}
		}


	}


	return {

		getData : getJSONData
		
	};

});