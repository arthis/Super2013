﻿// Knockout Mapping plugin v2.0.3
// (c) 2011 Steven Sanderson, Roy Jacobs - http://knockoutjs.com/
// License: Ms-Pl (http://www.opensource.org/licenses/ms-pl.html)

ko.exportSymbol = function (h, q) { for (var e = h.split("."), i = window, f = 0; f < e.length - 1; f++) i = i[e[f]]; i[e[e.length - 1]] = q }; ko.exportProperty = function (h, q, e) { h[q] = e };
(function () {
    function h(a, c) { for (var b in c) c.hasOwnProperty(b) && c[b] && (b && a[b] && !(a[b] instanceof Array) ? h(a[b], c[b]) : a[b] = c[b]) } function q(a, c) { var b = {}; h(b, a); h(b, c); return b } function e(a) { return a && "object" === typeof a && a.constructor == (new Date).constructor ? "date" : typeof a } function i(a, c) {
        a = a || {}; if (a.create instanceof Function || a.update instanceof Function || a.key instanceof Function || a.arrayChanged instanceof Function) a = { "": a }; if (c) a.ignore = f(c.ignore, a.ignore), a.include = f(c.include, a.include),
a.copy = f(c.copy, a.copy); a.ignore = f(a.ignore, g.ignore); a.include = f(a.include, g.include); a.copy = f(a.copy, g.copy); a.mappedProperties = a.mappedProperties || {}; return a
    } function f(a, c) { a instanceof Array || (a = "undefined" === e(a) ? [] : [a]); c instanceof Array || (c = "undefined" === e(c) ? [] : [c]); return a.concat(c) } function J(a, c) {
        var b = ko.dependentObservable; ko.dependentObservable = function (b, c, d) {
            var d = d || {}, j = d.deferEvaluation; b && "object" == typeof b && (d = b); var e = !1, v = function (b) {
                var c = n({ read: function () {
                    e || (ko.utils.arrayRemoveItem(a,
b), e = !0); return b.apply(b, arguments)
                }, write: function (a) { return b(a) }, deferEvaluation: !0
                }); c.__ko_proto__ = n; return c
            }; d.deferEvaluation = !0; b = new n(b, c, d); b.__ko_proto__ = n; j || (a.push(b), b = v(b)); return b
        }; ko.computed = ko.dependentObservable; var d = c(); ko.dependentObservable = b; ko.computed = ko.dependentObservable; return d
    } function z(a, c, b, d, u, f) {
        var y = ko.utils.unwrapObservable(c) instanceof Array, f = f || ""; if (ko.mapping.isMapped(a)) var j = ko.utils.unwrapObservable(a)[m], b = q(j, b); var g = function () {
            return b[d] &&
b[d].create instanceof Function
        }, v = function (a) { return J(C, function () { return b[d].create({ data: a || c, parent: u }) }) }, h = function () { return b[d] && b[d].update instanceof Function }, o = function (a, K) { var e = { data: K || c, parent: u, target: ko.utils.unwrapObservable(a) }; if (ko.isWriteableObservable(a)) e.observable = a; return b[d].update(e) }; if (j = A.get(c)) return j; d = d || ""; if (y) {
            var y = [], l = !1, k = function (a) { return a }; if (b[d] && b[d].key) k = b[d].key, l = !0; if (!ko.isObservable(a)) a = ko.observableArray([]), a.mappedRemove = function (b) {
                var c =
"function" == typeof b ? b : function (a) { return a === k(b) }; return a.remove(function (a) { return c(k(a)) })
            }, a.mappedRemoveAll = function (b) { var c = w(b, k); return a.remove(function (a) { return -1 != ko.utils.arrayIndexOf(c, k(a)) }) }, a.mappedDestroy = function (b) { var c = "function" == typeof b ? b : function (a) { return a === k(b) }; return a.destroy(function (a) { return c(k(a)) }) }, a.mappedDestroyAll = function (b) { var c = w(b, k); return a.destroy(function (a) { return -1 != ko.utils.arrayIndexOf(c, k(a)) }) }, a.mappedIndexOf = function (b) {
                var c = w(a(),
k), b = k(b); return ko.utils.arrayIndexOf(c, b)
            }, a.mappedCreate = function (b) { if (-1 !== a.mappedIndexOf(b)) throw Error("There already is an object with the key that you specified."); var c = g() ? v(b) : b; h() && (b = o(c, b), ko.isWriteableObservable(c) ? c(b) : c = b); a.push(c); return c }; var j = w(ko.utils.unwrapObservable(a), k).sort(), i = w(c, k); l && i.sort(); for (var l = ko.utils.compareArrays(j, i), j = {}, i = [], n = 0, t = l.length; n < t; n++) {
                var s = l[n], r, p = f + "[" + n + "]"; switch (s.status) {
                    case "added": var x = B(ko.utils.unwrapObservable(c), s.value,
k); r = ko.utils.unwrapObservable(z(void 0, x, b, d, a, p)); p = F(ko.utils.unwrapObservable(c), x, j); i[p] = r; j[p] = !0; break; case "retained": x = B(ko.utils.unwrapObservable(c), s.value, k); r = B(a, s.value, k); z(r, x, b, d, a, p); p = F(ko.utils.unwrapObservable(c), x, j); i[p] = r; j[p] = !0; break; case "deleted": r = B(a, s.value, k)
                } y.push({ event: s.status, item: r })
            } a(i); b[d] && b[d].arrayChanged && ko.utils.arrayForEach(y, function (a) { b[d].arrayChanged(a.event, a.item) })
        } else if (D(c)) {
            a = ko.utils.unwrapObservable(a); if (!a) {
                if (g()) return l = v(), h() &&
(l = o(l)), l; if (h()) return o(l); a = {}
            } h() && (a = o(a)); A.save(c, a); G(c, function (d) { var e = f.length ? f + "." + d : d; if (-1 == ko.utils.arrayIndexOf(b.ignore, e)) if (-1 != ko.utils.arrayIndexOf(b.copy, e)) a[d] = c[d]; else { var u = A.get(c[d]) || z(a[d], c[d], b, d, a, e); if (ko.isWriteableObservable(a[d])) a[d](ko.utils.unwrapObservable(u)); else a[d] = u; b.mappedProperties[e] = !0 } })
        } else switch (e(c)) {
            case "function": h() ? ko.isWriteableObservable(c) ? (c(o(c)), a = c) : a = o(c) : a = c; break; default: ko.isWriteableObservable(a) ? h() ? a(o(a)) : a(ko.utils.unwrapObservable(c)) :
(a = g() ? v() : ko.observable(ko.utils.unwrapObservable(c)), h() && a(o(a)))
        } return a
    } function F(a, c, b) { for (var d = 0, e = a.length; d < e; d++) if (!0 !== b[d] && a[d] === c) return d; return null } function H(a, c) { var b; c && (b = c(a)); "undefined" === e(b) && (b = a); return ko.utils.unwrapObservable(b) } function B(a, c, b) {
        a = ko.utils.arrayFilter(ko.utils.unwrapObservable(a), function (a) { return H(a, b) === c }); if (0 == a.length) throw Error("When calling ko.update*, the key '" + c + "' was not found!"); if (1 < a.length && D(a[0])) throw Error("When calling ko.update*, the key '" +
c + "' was not unique!"); return a[0]
    } function w(a, c) { return ko.utils.arrayMap(ko.utils.unwrapObservable(a), function (a) { return c ? H(a, c) : a }) } function G(a, c) { if (a instanceof Array) for (var b = 0; b < a.length; b++) c(b); else for (b in a) c(b) } function D(a) { var c = e(a); return "object" === c && null !== a && "undefined" !== c } function I() { var a = [], c = []; this.save = function (b, d) { var e = ko.utils.arrayIndexOf(a, b); 0 <= e ? c[e] = d : (a.push(b), c.push(d)) }; this.get = function (b) { b = ko.utils.arrayIndexOf(a, b); return 0 <= b ? c[b] : void 0 } } ko.mapping =
{}; var m = "__ko_mapping__", n = ko.dependentObservable, E = 0, C, A, t = { include: ["_destroy"], ignore: [], copy: [] }, g = t; ko.mapping.isMapped = function (a) { return (a = ko.utils.unwrapObservable(a)) && a[m] }; ko.mapping.fromJS = function (a) {
    if (0 == arguments.length) throw Error("When calling ko.fromJS, pass the object you want to convert."); window.setTimeout(function () { E = 0 }, 0); E++ || (C = [], A = new I); var c, b; 2 == arguments.length && (arguments[1][m] ? b = arguments[1] : c = arguments[1]); 3 == arguments.length && (c = arguments[1], b = arguments[2]); b &&
(c = q(c, b[m])); c = i(c); var d = z(b, a, c); b && (d = b); --E || window.setTimeout(function () { ko.utils.arrayForEach(C, function (a) { a && a() }) }, 0); d[m] = q(d[m], c); return d
}; ko.mapping.fromJSON = function (a) { var c = ko.utils.parseJson(a); arguments[0] = c; return ko.mapping.fromJS.apply(this, arguments) }; ko.mapping.updateFromJS = function () { throw Error("ko.mapping.updateFromJS, use ko.mapping.fromJS instead. Please note that the order of parameters is different!"); }; ko.mapping.updateFromJSON = function () {
    throw Error("ko.mapping.updateFromJSON, use ko.mapping.fromJSON instead. Please note that the order of parameters is different!");
}; ko.mapping.toJS = function (a, c) {
    g || ko.mapping.resetDefaultOptions(); if (0 == arguments.length) throw Error("When calling ko.mapping.toJS, pass the object you want to convert."); if (!(g.ignore instanceof Array)) throw Error("ko.mapping.defaultOptions().ignore should be an array."); if (!(g.include instanceof Array)) throw Error("ko.mapping.defaultOptions().include should be an array."); if (!(g.copy instanceof Array)) throw Error("ko.mapping.defaultOptions().copy should be an array."); c = i(c, a[m]); return ko.mapping.visitModel(a,
function (a) { return ko.utils.unwrapObservable(a) }, c)
}; ko.mapping.toJSON = function (a, c) { var b = ko.mapping.toJS(a, c); return ko.utils.stringifyJson(b) }; ko.mapping.defaultOptions = function () { if (0 < arguments.length) g = arguments[0]; else return g }; ko.mapping.resetDefaultOptions = function () { g = { include: t.include.slice(0), ignore: t.ignore.slice(0), copy: t.copy.slice(0)} }; ko.mapping.visitModel = function (a, c, b) {
    b = b || {}; b.visitedObjects = b.visitedObjects || new I; b.parentName || (b = i(b)); var d, f = ko.utils.unwrapObservable(a);
    if (D(f)) c(a, b.parentName), d = f instanceof Array ? [] : {}; else return c(a, b.parentName); b.visitedObjects.save(a, d); var h = b.parentName; G(f, function (a) {
        if (!(b.ignore && -1 != ko.utils.arrayIndexOf(b.ignore, a))) {
            var j = f[a], i = b, g = h || ""; f instanceof Array ? h && (g += "[" + a + "]") : (h && (g += "."), g += a); i.parentName = g; if (!(-1 === ko.utils.arrayIndexOf(b.copy, a) && -1 === ko.utils.arrayIndexOf(b.include, a) && f[m] && f[m].mappedProperties && !f[m].mappedProperties[a] && !(f instanceof Array))) switch (e(ko.utils.unwrapObservable(j))) {
                case "object": case "undefined": i =
b.visitedObjects.get(j); d[a] = "undefined" !== e(i) ? i : ko.mapping.visitModel(j, c, b); break; default: d[a] = c(j, b.parentName)
            } 
        } 
    }); return d
}; ko.exportSymbol("ko.mapping", ko.mapping); ko.exportSymbol("ko.mapping.fromJS", ko.mapping.fromJS); ko.exportSymbol("ko.mapping.fromJSON", ko.mapping.fromJSON); ko.exportSymbol("ko.mapping.isMapped", ko.mapping.isMapped); ko.exportSymbol("ko.mapping.defaultOptions", ko.mapping.defaultOptions); ko.exportSymbol("ko.mapping.toJS", ko.mapping.toJS); ko.exportSymbol("ko.mapping.toJSON",
ko.mapping.toJSON); ko.exportSymbol("ko.mapping.updateFromJS", ko.mapping.updateFromJS); ko.exportSymbol("ko.mapping.updateFromJSON", ko.mapping.updateFromJSON); ko.exportSymbol("ko.mapping.visitModel", ko.mapping.visitModel)
})();