var webpackMerge = require('webpack-merge'),
   commonConfig = require('./webpack.common');

module.exports = webpackMerge(commonConfig, {
   output: {
      path: '../wwwroot',
      publicPath: 'http://localhost:5000',
      filename: '[name].js',
      chunkFilename: '[id].chunk.js'
   }
});