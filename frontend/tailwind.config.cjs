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
          'base-content': '#f8f7f6',
          'base-100': '#11100e',
          'base-200': '#12110F',
          neutral: '#FFF',
          error: '#EA514D',
          success: '#24E454'
        },
        dark_theme: {
          primary: '#8f7756',
          secondary: '#5b462f',
          accent: '#87653b',
          background: '#090807',
          'base-content': '#090807',
          'base-100': '#f1f0ee',
          'base-200': '#AAA',
          neutral: '#111',
          error: '#933431',
          success: '#0D511E'
        }
      }
    ],
    darkTheme: 'dark', // name of one of the included themes for dark mode
    base: true, // applies background color and foreground color for root element by default
    styled: true, // include daisyUI colors and design decisions for all components
    utils: true, // adds responsive and modifier utility classes
    prefix: '', // prefix for daisyUI classnames (components, modifiers and responsive class names. Not colors)
    logs: true, // Shows info about daisyUI version and used config in the console when building your CSS
    themeRoot: ':root' // The element that receives theme color CSS variables
  }
}
