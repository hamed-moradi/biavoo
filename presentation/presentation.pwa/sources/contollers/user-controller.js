(function () {
    'use strict';

    app.controller('userController', userController);

    userController.$inject = ['$location'];

    function userController($location) {
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'userController';

        activate();

        function activate() { }
    }
})();
