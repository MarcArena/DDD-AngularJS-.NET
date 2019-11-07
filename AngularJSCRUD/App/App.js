var module = angular.module("myFormApp", ['ngRoute']);

module.config(function ($routeProvider) {

    function build(_controller, _templateUrl) {
        return {
            controller: _controller,
            templateUrl: _templateUrl
        };
    }

    $routeProvider.when("/", build(
        "homeController",
        "/home/index"
    ));

    configureUsersRoutes();

    $routeProvider.otherwise({ redirectTo: "/" });


    function configureUsersRoutes() {
        $routeProvider.when("/agents", build(
            "AgentListController",
            "/agents/List"
        ));

        $routeProvider.when("/agents/create", build(
            "AgentCreateController",
            "/agents/Create"
        ));

        $routeProvider.when("/agents/edit/:id", build(
            "AgentEditController",
            "/agents/Edit"
        ));

        $routeProvider.when("/agents/details/:id", build(
            "AgentDetailsController",
            "/agents/Details"
        ));

        $routeProvider.when("/agents/delete/:id", build(
            "AgentDeleteController",
            "/agents/Delete"
        ));
    }

});

