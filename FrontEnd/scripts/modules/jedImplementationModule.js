define(['scripts/modules/getLanguageData.js','scripts/jed.js'],function(languageData){

	var jedReady;

	require(['scripts/jed.js'], function(){

		jedReady = true;

	});

	var selectElement = document.getElementById("selectLanguage");
	var renderingArea = document.getElementById("rendering-area");
	var selectedContext = document.getElementById("selectContext");
	var selectedLanguage = selectElement.value;
	var submitBtn = document.getElementById("btn-change");
	var i18n;

	var updateLanguage = function(){

		// if(!jedReady)alert('sorry, still loading loading language libraries.');

		var data = JSON.parse(JSON.stringify(languageData.getData(selectElement.value)));
		var number_value = updateNumber();

		if (isNaN(number_value)){
			number_value = 1;
		}
		console.log(data);
		i18n = new Jed(data);
		
		console.log(selectedContext);
		if(selectedContext.value != "uni")
		{
	    	renderingArea.innerHTML = i18n.translate( "Development" ).onDomain(selectedLanguage).withContext(selectedContext.value).ifPlural(2).fetch(2);
		}
		else
		{

		   	 renderingArea.innerHTML = i18n.translate( "Development" ).onDomain(selectedLanguage).fetch();			
		}

		document.getElementById("sentence-container").innerHTML = i18n.translate("I own %d house").onDomain(selectedLanguage).ifPlural(number_value, "I own %d houses").fetch(number_value);
		   	 renderingArea.innerHTML = i18n.translate( "Development" ).onDomain(selectedLanguage).ifPlural(2).fetch(2);			
		}	

	};	

	selectElement.onchange = updateLanguage;

	var updateNumber = function(){
		var number_value = parseInt(document.getElementById("test-plural").value);
		// document.getElementById("sentence-container").innerHTML = i18n.translate("I own %d house").ifPlural(number_value, "I own %d houses").fetch(number_value);
		return number_value;
	}

	var updateSentence = function(){
		var number_value = updateNumber();
		document.getElementById("sentence-container").innerHTML = i18n.translate("I own %d house").onDomain(selectedLanguage).ifPlural(number_value, "I own %d houses").fetch(number_value);
	}

	submitBtn.onclick = updateSentence;

	var updateContext = function(){

		if(selectedContext.value!="uni")
		{
	    	renderingArea.innerHTML = i18n.translate( "Development" ).onDomain(selectedLanguage).withContext(selectedContext.value).ifPlural(2).fetch(2);
		}
		else
		{
		   	 renderingArea.innerHTML = i18n.translate( "Development" ).onDomain(selectedLanguage).ifPlural(2).fetch(2);			
		}
	}

	selectedContext.onchange = updateContext;


	var populateDefaultLanguage = function(){
				
		var language = window.navigator.userLanguage || window.navigator.language;
		var tot = selectElement.length;

		for(var i=0;i<tot;i++)
		{
			if(selectElement[i].value === language)
			{
				selectElement.selectedIndex = i;
				break;
			}
		}

		updateLanguage();

	};

	return {
		
		populateDefLang : populateDefaultLanguage
	};
});