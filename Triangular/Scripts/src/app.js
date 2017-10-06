
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
    const submitter = this.triangles.map(t => t.sides);
    this.$http.post('/api/triangle', submitter).then(res => {
        this.triangles.forEach((tri, idx) => tri.type = res.data[idx]);
    });
}


angular.module('triangular', []).controller('TriangleCtrl', ['$http', TriangleCtrl ]);