
const TriangleCtrl = function($http) {
    this.triangles = [
        1, 2, 3
    ];
}

TriangleCtrl.prototype.addTriangle = function() {
    this.triangles.push({
        sides: [0, 0, 0],
        type: ''
    });
}

TriangleCtrl.prototype.removeTriangle = function(index) {
    this.triangles.splice(index, 1);
}

angular.module('triangular', []).controller('TriangleCtrl', ['$http', TriangleCtrl ]);