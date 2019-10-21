/**
 * @param {string} name
 * @param {number} size
 * @param {string[]} abilities
 * @constructor
 */
function Dinosaur(name, size, abilities) {
    this.name = name;
    this.size = size;
    this.abilities = abilities;
}

/**
 * Tells you whether a dinosaur is dangerous
 * @returns {boolean}
 */
Dinosaur.prototype.isDangerous = function() {
    if(this.size < 1)
        return false;
    
    return this.abilities.indexOf("claw") > -1
        || this.abilities.indexOf("bite") > -1
};

module.exports = Dinosaur;