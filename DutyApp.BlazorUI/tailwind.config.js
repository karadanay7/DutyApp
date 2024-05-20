module.exports = {
  content: [
    "./**/*.razor",
    "./**/*.html",
    "./**/*.cshtml",
    "./**/*.js"
  ],
  theme: {
    extend: {},
  },
  plugins: [
    require('daisyui'),
  ],
  daisyui: {
    themes: ["light", "dark"], // Add themes as needed
  }
}
