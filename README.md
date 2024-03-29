# PisoNetSim_Console

## Overview
PisoNetSim_Console is a Pisonet Coin Counter System designed in C# for managing the usage and finances of Pisonet or internet rental stations. It caters to two types of users: User and Owner.

### User
As a User, you can access the system by providing your name and selecting the PC you wish to use. You will then be prompted to choose the type of coin you want to use for payment and specify the quantity of coins. After using the PC, you have the option to extend your stay or log out.

### Owner
Owners have access to additional functionalities after successful authentication. They can either check the money collected or take money from the system.

#### Check Money
This option allows the owner to view a comprehensive list of all the coins collected along with their quantities and the total income generated.

#### Take Money
Owners can withdraw funds from the system by specifying the desired amount. If the requested amount is available, the system will process the withdrawal and provide a confirmation message. Additionally, the system automatically adjusts the remaining coins, converting some coins to higher denominations if necessary. However, if the requested amount exceeds the available balance, an error message will be displayed.

## Getting Started
To use PisoNetSim_Console, follow these steps:

1. Clone the repository to your local machine.
2. Navigate to the directory containing the application files.
3. Run the program and follow the on-screen prompts.
4. If you are an Owner, make sure to authenticate with the correct credentials to access additional functionalities.

## Dependencies
- This application is built using C# programming language.
- No additional dependencies required.

## Contributors
- Jaermis

## License
This project is licensed under the MIT License - see the [LICENSE.md](https://github.com/Jaermis/PisoNetSim_Console/blob/main/LICENSE) file for details.

## Acknowledgments
- Special thanks to Engr. Julian N. Semblante for the teachings on Object-Oriented Programming.

## Support
For any inquiries or support, please contact jermynejosh.kaquilala@gmail.com.
