const Dinosaur = require("./Dinosaur");

describe("Dinosaur", function () {

    describe("isDangerous", function() {

        test("should be false when the dinosaur is smaller than 1 meter", function () {
            // Arrange
            const dinosaur = new Dinosaur("Microraptor", 0.6, [ "claw", "bite" ]);

            // Act
            const isDangerous = dinosaur.isDangerous();

            // Assert 
            expect(isDangerous).toBeFalsy();
        });

        test("should be false when the dinosaur cannot claw or bite", function () {
            // Arrange
            const dinosaur = new Dinosaur("Europasaurus", 6.2, [ "", "" ]);

            // Act
            const isDangerous = dinosaur.isDangerous();

            // Assert 
            expect(isDangerous).toBeFalsy();
        });

        test("should be true when the dinosaur is larger than 1m and can claw", function () {
            // Arrange
            const dinosaur = new Dinosaur("T-Rex", 6.2, [ "claw" ]);

            // Act
            const isDangerous = dinosaur.isDangerous();

            // Assert 
            expect(isDangerous).toBeTruthy(); 
        });

        test("should be true when the dinosaur is larger than 1m and can bite", function () {
            // Arrange
            const dinosaur = new Dinosaur("T-Rex", 6.2, [ "bite" ]);

            // Act
            const isDangerous = dinosaur.isDangerous();

            // Assert 
            expect(isDangerous).toBeTruthy(); 
        });
    });

});