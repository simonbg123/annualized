# annualized

## General Description


This personal desktop application project uses raw transaction histories for specific mutual funds held at a financial institution to calculate and output custom anualized rates of return from its transaction histories, and keeps fund records for future querying and history updates. 

Its purpose is to remedy the lack of information provided in such transaction histories and it is useful to obtain a more technical information regarding fund trends and performance where limited information is otherwise provided by the institution.

Any number of periods can be specified. For example, specifying periods of respectively 30, 60, 180, 365 and maximum days, a sample output would be:

    My Super Fund ABC

    Annualized rates as of May. 02, 2020

    47-day period: 3.95%
    starting Mar. 16, 2020

    74-day period: 6.57%
    starting Feb. 18, 2020

    199-day period: 4.63%
    starting Oct. 16, 2019

    382-day period: 2.90%
    starting Apr. 16, 2019

    Maximum 1419-day period: 0.76%
    starting Jun. 13, 2016


**Annualized rate of return** is meant to include capital appreciation as well as automatic profit redistribution through share purchasing, thus offering a realistic view of total capital appreciation for a given fund.

**Currently supported:** BMO transaction histories from personal banking website.

**Targeted OS:** Windows (.NET framework 4.7.2). Plans are being made to port this desktop application to other OSes through the .NET Core framework.	


## Main Features

An easy-to-use GUI is available to conduct a number of operations.

Most of the functionality is provided by two buttons:

- **Update and get Annualized!** : update or create records for a fund, and obtain annualized data. Must be supplied: the fund name (new or chosen from drop-down list), the period(s) for which annualized data is requested (leave blank for default values), the current price share, the current number of shares. A current transaction history needs to be copied as well to the input/output console at the bottom of the window. If new records were created, the fund's name will be added to the list of available funds.

- **Get Most Recent Annualized Data** : query existing records for a fund, targeting one or more periods. A fund name must be selected from the drop-down list of available funds, and one or more periods need to be specified (otherwise the default values will be used).

All output information appears in the intput/output console.

In addition, **back** and **forward** arrow buttons allow navigating back and forth the console history to retrieve previous input or output values.

Other buttons allow convenient clearing of the console or the textbox fields.

## Design Notes

Transaction histories for specific investments are parsed to a specific, uniform TSV format, and stored in .tsv files, which can be updated with recent histories. Funds that have such files can thus be queried or updated.

The code is organized in two projects: 
- AnnualizedGUI: contains the user interface
- AnnualizedLibrary: contains the TsvUpdater class in charge of creating, updating and backing up TSV records, and the Annualizer class, which reads the TSV files to calculate specific annualized rates of return, and returns or prints to a stream the formatted results.

There is also a Setup project to provide an installer.

See source files for additional information.

