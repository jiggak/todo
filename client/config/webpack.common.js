var webpack = require('webpack'),
   HtmlWebpackPlugin = require('html-webpack-plugin');

module.exports = {
   entry: {
      polyfills: './src/polyfills.ts',
      vendor: './src/vendor.ts',
      app: './src/main.ts'
   },

   resolve: {
      extensions: ['', '.js', '.ts']
   },

   module: {
      loaders: [
         {
            test: /\.ts$/,
            loaders: ['awesome-typescript-loader', 'angular2-template-loader']
         },
         {
            test: /\.html$/,
            loader: 'html'
         },
         {
            test: /\.less$/,
            loader: 'style!css!less'
         },
         {
            test: /\.(woff|woff2|svg|ttf)$/,
            loader: 'url?mimetype=application/font-woff'
         },
         {
            test: /\.eot$/,
            loader: 'file'
         }
      ]
   },

   plugins: [
      new webpack.optimize.CommonsChunkPlugin({
         name: ['app', 'vendor', 'polyfills']
      }),

      new HtmlWebpackPlugin({
         template: 'src/index.html'
      })
   ]
};
