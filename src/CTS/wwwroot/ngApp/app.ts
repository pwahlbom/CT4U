namespace CTS {

    angular.module('CTS', ['ui.router', 'ngResource', 'ui.bootstrap']).config((
        $stateProvider: ng.ui.IStateProvider,
        $urlRouterProvider: ng.ui.IUrlRouterProvider,
        $locationProvider: ng.ILocationProvider
    ) => {
        // Define routes
        $stateProvider
            .state('home', {
                url: '/',
                templateUrl: '/ngApp/views/viewHome.html',
                controller: CTS.Controllers.HomeController,
                controllerAs: 'controller'
            })
            .state('secret', {
                url: '/secret',
                templateUrl: '/ngApp/views/secret.html',
                controller: CTS.Controllers.SecretController,
                controllerAs: 'controller'
            })
            .state('receipts', {
                url: '/receipts',
                templateUrl: '/ngApp/views/viewReceipts.html',
                controller: CTS.Controllers.receiptsController,
                controllerAs: 'controller'
            })
            .state('products', {
                url: '/products',
                templateUrl: '/ngApp/views/viewProducts.html',
                controller: CTS.Controllers.productsController,
                controllerAs: 'controller'
            })
            .state('items', {
                url: '/items',
                templateUrl: '/ngApp/views/viewItems.html',
                controller: CTS.Controllers.itemsController,
                controllerAs: 'controller'
            })
            .state('profile', {
                url: '/profile',
                templateUrl: '/ngApp/views/viewProfile.html',
                controller: CTS.Controllers.applicationUsersController,
                controllerAs: 'controller'
            })
            .state('login', {
                url: '/login',
                templateUrl: '/ngApp/views/login.html',
                controller: CTS.Controllers.LoginController,
                controllerAs: 'controller'
            })
            .state('register', {
                url: '/register',
                templateUrl: '/ngApp/views/register.html',
                controller: CTS.Controllers.RegisterController,
                controllerAs: 'controller'
            })
            .state('externalRegister', {
                url: '/externalRegister',
                templateUrl: '/ngApp/views/externalRegister.html',
                controller: CTS.Controllers.ExternalRegisterController,
                controllerAs: 'controller'
            }) 
            .state('about', {
                url: '/about',
                templateUrl: '/ngApp/views/viewAbout.html',
                controller: CTS.Controllers.AboutController,
                controllerAs: 'controller'
            })
            .state('notFound', {
                url: '/notFound',
                templateUrl: '/ngApp/views/viewNotFound.html'
            });

        // Handle request for non-existent route
        $urlRouterProvider.otherwise('/notFound');

        // Enable HTML5 navigation
        $locationProvider.html5Mode(true);
    });

    
    angular.module('CTS').factory('authInterceptor', (
        $q: ng.IQService,
        $window: ng.IWindowService,
        $location: ng.ILocationService
    ) =>
        ({
            request: function (config) {
                config.headers = config.headers || {};
                config.headers['X-Requested-With'] = 'XMLHttpRequest';
                return config;
            },
            responseError: function (rejection) {
                if (rejection.status === 401 || rejection.status === 403) {
                    $location.path('/login');
                }
                return $q.reject(rejection);
            }
        })
    );

    angular.module('CTS').config(function ($httpProvider) {
        $httpProvider.interceptors.push('authInterceptor');
    });

    

}
