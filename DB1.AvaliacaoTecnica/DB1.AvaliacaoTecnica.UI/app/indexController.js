angular.module('db1.avaliacao.tecnica',['ngRoute'])
    .controller('IndexController', ['$scope', '$route', '$routeParams', '$location', function ($scope, $route, $routeParams, $location) {
        $scope.$route = $route;
        $scope.$location = $location;
        $scope.$routeParams = $routeParams;
    }])
    //Lista de Usuarios
    .controller('listarController', ['$scope', '$http', function ($scope, $http) {
        $scope.showCadastro = true;
        $scope.TodosUsuarios = [];
        $scope.url = "https://api.github.com/users?since=20";
        $scope.carregaUsuarios = function () {
            $http
                .get($scope.url)
                .success(function (data) {
                    $scope.TodosUsuarios = data;
                })
                .error(function () {
                });
        }
        $scope.carregaUsuarios();
    }])
    //Detalhes do usuario
    .controller('UsuarioController', ['$scope', '$routeParams', '$http', function ($scope, $routeParams, $http) {
        $scope.parametros = $routeParams;
        $scope.usuario = objUsuario();
        $scope.RepositoriosUsuario = [];
        $scope.ExibeAviso = false;
        $scope.ExibeRepositorios = false;
        $scope.url = "https://api.github.com/users/";
        $http
            .get($scope.url + $scope.parametros.id)
            .success(function (data) {
                $scope.usuario = data;
            })
            .error(function () {

            });
        $scope.carregaRepositoriosUsuario = function (name) {
            $http
                .get("https://api.github.com/users/" + name + "/repos")
                .success(function (data) {
                    if (data.length > 0) {
                        $scope.ExibeAviso = false;
                        $scope.ExibeRepositorios = true;
                        $scope.RepositoriosUsuario = data;
                    } else {
                        $scope.ExibeAviso = true;
                    }
                })
                .error(function () {
                    $scope.ExibeAviso = true;
                });
        }
    }])
    //rotas
    .config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {
        $routeProvider
            .when('/Index.html', {
                templateUrl: 'index.html',
                controller: 'InicialController'
            })
            .when('/Listar', {
                templateUrl: '/views/listar.html',
                controller: 'listarController'
            })
            .when('/Usuario/:id', {
                templateUrl: '/views/usuario.html',
                controller: 'UsuarioController'
            })
            .otherwise({
                redirectTo: '/'
            });
        $locationProvider.html5Mode(true);
    }]);

function objUsuario() {
    return {
        login: "",
        id: 0,
        avatar_url: "",
        url: "",
    };
}