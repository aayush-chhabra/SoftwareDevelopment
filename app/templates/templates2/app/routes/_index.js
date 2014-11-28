/**
 * Defines all the routes supported by the server. For the sake of
 * managability, it is recommended that routes be defined in individual
 * modules that are in turn loaded and used by this module.
 */

/* jshint node:true */
'use strict';

var _path = require('path');
var _express = require('express');
var _favicon = require('serve-favicon');
var _morgan = require('morgan');

module.exports = {
    apply: function(app) {
        //TODO: Apply routes here.
        app.get('/', function(req, res) {
            res.render('index', {
                title: 'MindApp Template',
                appConfig: app.get('cfg_config')
            });
        });
    }
};
