define([],function(){

	var findUserDefaultLanguage = function(){

		var language = window.navigator.userLanguage || window.navigator.language;
		return language;
	
	}

	return{
		userDefaultLanguage : findUserDefaultLanguage
	};

});