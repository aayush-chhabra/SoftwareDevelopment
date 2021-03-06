///////////////////////////////
// Dropdown Menus for Mobile
///////////////////////////////

jQuery(document).ready(function(){
		jQuery("<select />").appendTo("nav");
      		jQuery("<option />", {
		 	"selected": "selected",
		 	"value"   : "",
		 	"text"    : "Go to..."
	      	}).appendTo("nav select");
	      	jQuery("nav a").each(function() {
	       	var el = jQuery(this);
	       	jQuery("<option />", {
		   	"value"   : el.attr("href"),
		   	"text"    : el.text()
	       	}).appendTo("nav select");
	      	});
	      	jQuery("nav select").change(function() {
			window.location = jQuery(this).find("option:selected").val();
	      	}); 
});