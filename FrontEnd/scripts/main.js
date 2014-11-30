define(['modules/userDefaultLanguage','modules/jedImplementationModule'],
	
	function(userDefLang,jedImplMod){
		
		alert("Default language is : " + userDefLang.userDefaultLanguage());
		
		jedImplMod.populateDefLang();
		

	});