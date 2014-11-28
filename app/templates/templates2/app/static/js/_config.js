/**
 * RequireJS configuration.
 */
(function(appVersion) {
    'use strict';

    appVersion = appVersion || '';
    require.config({
        urlArgs: appVersion,
        baseUrl: 'js',
        paths: {
            jquery: '../lib/jquery/dist/jquery.min',
            angular: '../lib/angular/angular.min',
        },
        shim: {
            angular: {
                deps: ['jquery'],
                exports: 'angular'
            }
        },
        packages: []
    });
})(window.appVersion);
