var module = angular.module("myFormApp", ['ngRoute']);

module.config(function ($routeProvider, $locationProvider) {

    $locationProvider.html5Mode(false);

    function build(_controller, _templateUrl) {
        return {
            controller: _controller,
            templateUrl: _templateUrl
        };
    }

    $routeProvider.otherwise({ redirectTo: "/" });
        
    $routeProvider.when("/", build(
        "homeController",
        "/home/index"
    ));

    configureLoginFormsRoutes();
        
    function configureLoginFormsRoutes() {
        $routeProvider.when("/login", build(
            "LoginFormsController",
            "/LoginForms/List"
        ));
    }    
});