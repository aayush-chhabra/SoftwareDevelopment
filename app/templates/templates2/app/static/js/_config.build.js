/**
 * RequireJS configuration used by the r.js optimizer.
 */
/* jshint globalstrict:true */
'use strict';

require.config({
    baseUrl: 'js',
    paths: {
        jquery: '../lib/jquery/dist/jquery',
        angular: '../lib/angular/angular',
    },
    shim: {
        angular: {
            deps: ['jquery'],
            exports: 'angular'
        }
    },
    packages: []
});
