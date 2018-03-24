'use strict';
module.exports = {};
const form = require("./form.js")
const sendToApi = require("./sendToApi.js")
const render = require("./render.js")
const drag_drop = require("./drag_drop.js")
const colour_picker = require("./render.js")
const router = require("./router.js")
const lights = require("./lights.js")
const tooltip = require("./tooltip.js");
Object.assign(module.exports, form, sendToApi, render, router, drag_drop, colour_picker, lights, tooltip);

