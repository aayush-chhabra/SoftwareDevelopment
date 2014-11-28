/** 
 * Main file - loads all of the other modules required by the app, and
 * bootstraps AngularJS.
 */

 // Insert the module name in here in the require thing
require(['angular'], function(angular) {
    'use strict';

    angular.bootstrap(document, [moduleName]);
    console.debug('Application launched');
});
