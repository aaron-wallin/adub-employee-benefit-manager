export class EmployeeBenefitPayModel {
    employeeId: string;
    firstName: string;
    lastName: string;
    benefitInfo: {
        baseAnnualCost: number,
        discountApplied: boolean,
        discountedAnnualCost: number
    };
    benefitInfoSummary: {
        baseAnnualCost: number,
        discountApplied: boolean,
        discountedAnnualCost: number
    };
    paycheck: {
        grossAmount: number,
        netAmount: number,
        deductions: [
            {key: string, value: number}
        ]
    };
    dependents: [{
        firstName: string,
        lastName: string,
        benefitInfo:
        {
            baseAnnualCost
            discountApplied
            discountedAnnualCost
        }
    }];
}
