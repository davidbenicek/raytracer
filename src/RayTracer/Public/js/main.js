module.exports = {};
const form = require("./form.js")
const sendToApi = require("./sendToApi.js")
const render = require("./render.js")
const drag_drop = require("./drag_drop.js")
const colour_picker = require("./render.js")
const router = require("./router.js")
Object.assign(module.exports, form, sendToApi, render, drag_drop, colour_picker);
