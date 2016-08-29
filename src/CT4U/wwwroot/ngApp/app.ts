namespace CT4U {

    angular.module('CT4U', ['ui.router', 'ngResource', 'ui.bootstrap']).config((
        $stateProvider: ng.ui.IStateProvider,
        $urlRouterProvider: ng.ui.IUrlRouterProvider,
        $locationProvider: ng.ILocationProvider
    ) => {
        // Define routes
        $stateProvider
            .state('home', {
                url: '/',
                templateUrl: '/ngApp/views/view_Home.html',
                controller: CT4U.Controllers.HomeController,
                controllerAs: 'controller'
            })
            .state('secret', {
                url: '/secret',
                templateUrl: '/ngApp/views/view_Secret.html',
                controller: CT4U.Controllers.SecretController,
                controllerAs: 'controller'
            })
            .state('receipts', {
                url: '/receipts',
                templateUrl: '/ngApp/views/view_Receipts.html',
                controller: CT4U.Controllers.ReceiptsController,
                controllerAs: 'controller'
            })
            .state('products', {
                url: '/products',
                templateUrl: '/ngApp/views/view_Products.html',
                controller: CT4U.Controllers.ProductsController,
                controllerAs: 'controller'
            })
            .state('items', {
                url: '/items',
                templateUrl: '/ngApp/views/view_Items.html',
                controller: CT4U.Controllers.ItemsController,
                controllerAs: 'controller'
            })
            .state('report', {
                url: '/report',
                templateUrl: '/ngApp/views/view_Report.html',
                controller: CT4U.Controllers.ReportController,
                controllerAs: 'controller'
            })
            .state('profile', {
                url: '/profile',
                templateUrl: '/ngApp/views/view_Profile.html',
                controller: CT4U.Controllers.ProfileController,
                controllerAs: 'controller'
            })
            .state('login', {
                url: '/login',
                templateUrl: '/ngApp/views/view_Login.html',
                controller: CT4U.Controllers.LoginController,
                controllerAs: 'controller'
            })
            .state('register', {
                url: '/register',
                templateUrl: '/ngApp/views/view_Register.html',
                controller: CT4U.Controllers.RegisterController,
                controllerAs: 'controller'
            })
            .state('externalRegister', {
                url: '/externalRegister',
                templateUrl: '/ngApp/views/view_ExternalRegister.html',
                controller: CT4U.Controllers.ExternalRegisterController,
                controllerAs: 'controller'
            }) 
            .state('about', {
                url: '/about',
                templateUrl: '/ngApp/views/view_About.html',
                controller: CT4U.Controllers.AboutController,
                controllerAs: 'controller'
            })
            .state('notFound', {
                url: '/notFound',
                templateUrl: '/ngApp/views/view_NotFound.html'
            });

        // Handle request for non-existent route
        $urlRouterProvider.otherwise('/notFound');

        // Enable HTML5 navigation
        $locationProvider.html5Mode(true);
    });

    
    angular.module('CT4U').factory('authInterceptor', (
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

    angular.module('CT4U').config(function ($httpProvider) {
        $httpProvider.interceptors.push('authInterceptor');
    });

    

}
