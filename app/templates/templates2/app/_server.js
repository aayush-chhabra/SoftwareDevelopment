/**
 * Main module that launches the web server. This file typically will not
 * require changes. Route changes have to be made in the ./routes sub package,
 * and configuration changes can be introduced using the ./config.js file.
 */

/* jshint node:true */
'use strict';

var _path = require('path');
var _http = require('http');

var _express = require('express');
var _routes = require('./routes');
var _config = require('./config');

var app = _express();

var env = app.get('env');

// Basic configuration
app.set('cfg_static_dir', _path.join(__dirname, 'static'));
app.set('cfg_config', {
    mainFile: 'app.min.js',
    version: '1.0.0'
});

app.set('port', process.env.PORT || 3030);
app.set('views', _path.join(__dirname, 'views'));
app.set('view engine', 'jade');

// Environment specific configuration.
var env = app.get('env');
var configure = _config[env];
if (!configure) {
    console.warn('no configuration found for environment:', env);
} else {
    configure(app);
}

// Route configuration.
_routes.apply(app);

// Launch server.
_http.createServer(app).listen(app.get('port'), function() {
    var SEPARATOR = (new Array(81)).join('-');
    console.log(SEPARATOR);
    console.log('Express server started: ');
    console.log('Mode:', app.get('env'));
    console.log('Port:', app.get('port'));
    console.log(SEPARATOR);
});
