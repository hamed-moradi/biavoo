(function () {
    'use strict';

    app.controller('businessController', businessController);

    businessController.$inject = ['$scope'];

    function businessController($scope) {
        $scope.title = 'businessController';

        activate();

        function activate() { }
    }
})();
