'use strict';
var util = require('util');
var path = require('path');
var yeoman = require('yeoman-generator');
var yosay = require('yosay');
var chalk = require('chalk');


var FirstGenerator = yeoman.generators.Base.extend({
  init: function () {
    
  },

  askFor: function () {
    this.log(yosay("Welcome!!!!! This generator scaffolds the basic structure of a Mindapp!!"));
  },

  app: function () {

    this.mkdir('app');
    this.mkdir('app/routes');
    this.mkdir('app/static');
    this.mkdir('app/static/css');
    this.mkdir('app/static/img');
    this.mkdir('app/static/js');
    // this.mkdir('app/static/js/hello-world-module');

    this.mkdir('app/static/lib');

    this.mkdir('app/views');

    this.mkdir('test');
    this.mkdir('test/e2e');
    this.mkdir('test/mocks');
    this.mkdir('test/spec');
    //this.mkdir('test/spec/hello-world-module');
    

    this.copy('templates2/app/_config.js','app/config.js');
    this.copy('templates2/app/_server.js','app/server.js'); 

    this.copy('templates2/app/routes/_index.js','app/routes/index.js');

    this.copy('templates2/app/static/css/_app.css','app/static/css/app.css'); 
    this.copy('templates2/app/static/css/_app.scss','app/static/css/app.scss');
    this.copy('templates2/app/static/js/_app.js','app/static/js/app.js');
    this.copy('templates2/app/static/js/_config.build.js','app/static/js/config.build.js');
    this.copy('templates2/app/static/js/_config.js','app/static/js/config.js');
    this.copy('templates2/app/static/js/_require.js','app/static/js/require.js');


    this.copy('templates2/app/views/_index.jade','app/views/index.jade');
    this.copy('templates2/app/views/_layout.jade','app/views/layout.jade');

    this.copy('templates2/_bower.json','bower.json');
    this.copy('templates2/_Gruntfile.js','Gruntfile.js'); 
    this.copy('templates2/_package.json','package.json');
    this.copy('templates2/_README.md','README.md');

    this.copy('templates2/test/e2e/_home-page-test.js','test/e2e/home-page-test.js');
    this.copy('templates2/test/mocks/_test-fixture-module.js','test/mocks/test-fixture-module.js');

    this.copy('templates2/test/spec/_bootstrap.js','test/spec/bootstrap.js');
    this.copy('templates2/test/spec/_config.build.js','test/spec/config.build.js');
    this.copy('templates2/test/spec/_config.dev.js','test/spec/config.dev.js');

    this.directory('lib/','app/static/lib/');

    this.copy('favicon.ico','app/static/img/favicon.ico');

    this.directory('cldrjs-master/','cldrjs-master/');


  },

  projectfiles: function () {
    this.copy('editorconfig', '.editorconfig');
    this.copy('jshintrc', '.jshintrc');
  }
});

module.exports = FirstGenerator;
