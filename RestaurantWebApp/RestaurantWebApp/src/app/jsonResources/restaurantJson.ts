export class RestaurantJson {
    public static readonly restaurantOne = `
    {
        "ingredientes": {
        "nome": "farinha",
        "quantidade": "2"
        },
        "modoPreparo": "Deve se misturar..."
        }
    `;

    public static readonly restaurantTwo =
        `{
            "recipe": {
            "ingredients": [{
            "nome": "farinha",
            "quantity": "100mg"
            }],
            "instructions": "Deve se misturar..."
            }
        }`
        ;

    public static readonly restaurantThree = `
    {
        "recipeRestaurant":{
            "ingredients": [{
                "nomeReceita": "açúcar",
                "quantidade": "200g"},{
                "nomeReceita": "manteiga",
                "quantidade": "10g"},{
                "nomeReceita": "nescal",
                "quantidade": "60g"}
            ],
            "instructions": "Misture o açúcar com a farinha...",
            "classification": 4,
            "time": 1
            }
        }`;

    public static readonly restaurantFour = `{
        "recipe": {
            "ingredientes": [{
                "nome": "ovos",
                "quantity": "3"
            }],
            "metodoDePreparo": "Bata os ovos...",
            "tempoDePreparo": 0.5,
            "avaliacao": 3
        }
    }`;

    public static readonly restaurantFive = `{
        "ingredientList": [{
            "fullName": "fermento",
            "qtd": "1 colher de chá"
        }],
        "instructions": "Adicione o fermento à mistura...",
        "assessment": "5",
        "timeOfPreparation": 1.5
    }`;
}