import { Dinosaur2 } from "./Dinosaur2";

describe("Dinosaur2", () => {

    describe("isDangerous", () => {

        test("should be false when the dinosaur is smaller than 1 meter", () =>  {
            // Arrange
            const dinosaur = new Dinosaur2("Microraptor", 0.6, [ "claw", "bite" ]);

            // Act
            const isDangerous = dinosaur.isDangerous();

            // Assert 
            expect(isDangerous).toBeFalsy();
        });

        test("should be false when the dinosaur cannot claw or bite", () =>  {
            // Arrange
            const dinosaur = new Dinosaur2("Europasaurus", 6.2, [ "", "" ]);

            // Act
            const isDangerous = dinosaur.isDangerous();

            // Assert 
            expect(isDangerous).toBeFalsy();
        });

        test("should be true when the dinosaur is larger than 1m and can claw", () =>  {
            // Arrange
            const dinosaur = new Dinosaur2("T-Rex", 6.2, [ "claw" ]);

            // Act
            const isDangerous = dinosaur.isDangerous();

            // Assert 
            expect(isDangerous).toBeTruthy();
        });

        test("should be true when the dinosaur is larger than 1m and can bite", () =>  {
            // Arrange
            const dinosaur = new Dinosaur2("T-Rex", 6.2, [ "bite" ]);

            // Act
            const isDangerous = dinosaur.isDangerous();

            // Assert 
            expect(isDangerous).toBeTruthy();
        });
    });

});