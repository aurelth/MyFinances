import { Component, OnInit } from '@angular/core';
import { ExpenseService } from 'src/services/services/expense.service';
import { Expense } from 'src/models/expense.model';

@Component({
  selector: 'app-expense-list',
  templateUrl: './expense-list.component.html',
  styleUrls: ['./expense-list.component.scss']
})
export class ExpenseListComponent implements OnInit {
  expenses: Expense[] = [];
  filteredExpenses: Expense[] = [];
  totalExpenses: number = 0;
  selectedMonth: string = '';
  months: string[] = [
    'January', 'February', 'March', 'April', 'May', 'June',
    'July', 'August', 'September', 'October', 'November', 'December'
  ];

  constructor(private expenseService: ExpenseService) { }

  ngOnInit(): void {
    this.loadExpenses();
  }

  loadExpenses(): void {
    this.expenseService.getExpenses().subscribe(data => {
      this.expenses = data;
      this.filterByMonth();
    });
  }

  filterByMonth(): void {
    const monthIndex = this.months.indexOf(this.selectedMonth) + 1;
    this.filteredExpenses = this.expenses.filter(expense =>
      new Date(expense.date).getMonth() + 1 === monthIndex
    );
    this.calculateTotal();
  }

  calculateTotal(): void {
    this.totalExpenses = this.filteredExpenses.reduce((sum, expense) => sum + expense.amount, 0);
  }

  editExpense(expense: Expense): void {
    // I will implement edit functionality soon
  }

  deleteExpense(id: number): void {
    this.expenseService.deleteExpense(id).subscribe(() => {
      this.loadExpenses();
    });
  }
}
