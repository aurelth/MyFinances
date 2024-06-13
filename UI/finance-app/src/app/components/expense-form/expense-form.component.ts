import { Component, OnInit } from '@angular/core';
import { ExpenseService } from 'src/services/services/expense.service';
import { Expense } from 'src/models/expense.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-expense-form',
  templateUrl: './expense-form.component.html',
  styleUrls: ['./expense-form.component.scss'],
})
export class ExpenseFormComponent implements OnInit {
  expense: Expense = { id: 0, name: '', amount: 0, date: new Date() };

  constructor(private expenseService: ExpenseService, private router: Router) {}

  ngOnInit(): void {}

  onSubmit(): void {
    if (this.expense.id === 0) {
      this.expenseService.addExpense(this.expense).subscribe(() => {
        this.router.navigate(['/']);
      });
    } else {
      this.expenseService.updateExpense(this.expense).subscribe(() => {
        this.router.navigate(['/']);
      });
    }
  }
}
