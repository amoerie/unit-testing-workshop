export class Dinosaur2 {
    public readonly name: string;
    public readonly size: number;
    public readonly abilities: string[];
    
    constructor(
        name: string,
        size: number,
        abilities: string[]
    ) {
        this.name = name;
        this.size = size;
        this.abilities = abilities;
    }
    
    isDangerous() {
        const { size, abilities } = this; 
        if(size < 1)
            return false;

        return abilities.indexOf("claw") > -1
            || abilities.indexOf("bite") > -1;
    }
    
}