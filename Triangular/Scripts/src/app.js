
const TriangleCtrl = function($http) {
    this.$http = $http;
    this.triangles = [
        { sides: [0, 0, 0], type: '' },
        { sides: [0, 0, 0], type: '' }
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

TriangleCtrl.prototype.classify = function() {
    this.triangles = this.triangles.map(t => Object.assign(t, { type: 'Scalene' }));
}


angular.module('triangular', []).controller('TriangleCtrl', ['$http', TriangleCtrl ]);