/**
 * Defines configuration settings for the server. The module returns a hash,
 * with one key for every environment that is supported. The value of each
 * key is a function that will be invoked to configure the app.
 */

/* jshint node:true */
'use strict';

var _fs = require('fs');
var _path = require('path');
var _express = require('express');
var _favicon = require('serve-favicon');
var _morgan = require('morgan');
var _sassMiddleware = require('node-sass-middleware');


var _packageCfg;
try {
    console.log(__dirname);
    var filePath = _path.join(__dirname, '../package.json');
    var data = _fs.readFileSync(filePath);
    _packageCfg = JSON.parse(data.toString());
} catch (err) {
    console.error('Error reading package.json: ', err);
}

module.exports = {
    /**
     * Configuration setttings for when the server is run on a development
     * environment.
     */
    development: function(app) {
        var staticDir = app.get('cfg_static_dir');

        app.use(_favicon(_path.join(staticDir, 'img/favicon.ico')));
        app.use(_morgan('dev')); //Logger
        app.use(_sassMiddleware({
            src: staticDir,
            debug: true,
            render: true,
            outputStyle: 'nested'
        }));
        app.use(_express.static(staticDir));

        var appConfig = app.get('cfg_config');
        appConfig.mainFile = 'js/app.js';
        appConfig.version = _packageCfg.version + '__' + (new Date()).getTime();
    },

    /**
     * Configuration setttings for when the server is run on an integration
     * test/qa environment.
     */
    qa: function(app) {
        var staticDir = app.get('cfg_static_dir');

        app.use(_favicon(_path.join(staticDir, 'img/favicon.ico')));
        app.use(_morgan('dev')); //Logger
        app.use(_express.static(staticDir));

        var appConfig = app.get('cfg_config');
        appConfig.mainFile = 'js/app.min.js';
        appConfig.version = _packageCfg.version;
    },

    /**
     * Configuration setttings for when the server is run on an integration
     * production environment.
     */
    production: function(app) {
        var staticDir = app.get('cfg_static_dir');
        var cacheDuration = 31356000000;

        app.use(_favicon(_path.join(staticDir, 'img/favicon.ico')));
        app.use(_express.static(staticDir, {
            maxAge: cacheDuration
        }));

        var appConfig = app.get('cfg_config');
        appConfig.mainFile = 'js/app.min.js';
        appConfig.version = _packageCfg.version;
    }
};
