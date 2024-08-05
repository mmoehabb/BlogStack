const { default: daisyui } = require('daisyui')

module.exports = {
  content: ['./src/**/*.{vue,js,ts}'],
  theme: {
    extend: {}
  },
  plugins: [require('daisyui')],
  daisyui: {
    themes: [
      {
        light_theme: {
          primary: '#a88e6f',
          secondary: '#d0bba3',
          accent: '#c4a279',
          background: '#f8f7f6',
          'base-100': '#11100e'
        },
        dark_theme: {
          primary: '#8f7756',
          secondary: '#5b462f',
          accent: '#87653b',
          background: '#090807',
          'base-100': '#f1f0ee'
        }
      }
    ]
  }
}
