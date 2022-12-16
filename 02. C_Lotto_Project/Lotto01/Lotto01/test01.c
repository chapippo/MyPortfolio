#include<stdio.h>
#include<stdlib.h>
#include<time.h>

// 매크로 상수 선언
#define SIZE 6

// 전역변수 선언
//void rand_num(int n);
//int odd_check(int snum[], int size);
//int even_check(int snum[], int size);
//int lotto[SIZE];

void bubbleSort(int arr[], int size) // 오름차순 정렬 (버블정렬)
{
	int temp = 0;
	for (int i = 0; i < size; i++)
	{
		for (int j = 0; j < size; j++)
		{
			if (arr[i] < arr[j])
			{
				temp = arr[i];
				arr[i] = arr[j];
				arr[j] = temp;
			}
		}
	}
}

int odd_check(int snum[], int size) // 모두 홀수인지 판별하는 함수(수를 2로 나눴을 때 '1'이라면 홀수)
{
	int check[SIZE];
	for (int i = 0; i < size; i++)
	{
		check[i] = (snum[i] % 1);
	}
	if (check[0] == 1 && check[1] == 1 && check[2] == 1 && check[3] == 1 && check[4] == 1 && check[5] == 1)
		return 1;
	else
		return 0;
}

int even_check(int snum[], int size) // 모두 짝수인지 판별하는 함수(수를 2로 나눴을 때 '0'이라면 짝수)
{
	int check[SIZE];
	for (int i = 0; i < size; i++)
	{
		check[i] = (snum[i] % 2);
	}
	if (check[0] == 0 && check[1] == 0 && check[2] == 0 && check[3] == 0 && check[4] == 0 && check[5] == 0)
		return 1;
	else
		return 0;
}

void rand_num(int n)
{
	int odd, even;
	int num[6]; // 랜덤 생성된 로또번호
	int lotto[6] = { 0 }; // 비교될 로또번호
	srand(time(NULL));

	for (int j = 0; j < n; j++)
	{
		odd = 0;
		even = 0;
		for (int i = 0; i < SIZE; i++)
		{
			num[i] = (rand() % 45 + 1); 
			if (num[i] != lotto[0] && num[i] != lotto[1] && num[i] != lotto[2] &&
				num[i] != lotto[3] && num[i] != lotto[4] && num[i] != lotto[5])
			{ // 같은 줄에 같은 숫자가 있는지 배열 전체와 비교
				lotto[i] = num[i]; // 일치하지 않으면 대입
			}
			else
			{
				i--;
			}
		}

		bubbleSort(lotto, 6);
		odd = odd_check(lotto, SIZE);
		even = even_check(lotto, SIZE);

		if (odd == 1 || even == 1) // 체크 후 하나라도 1이 나올 경우 번호 재생성
		{
			j--;
		}
		else
		{
			printf("%2d세트 : ", j+1);
			for (int i = 0; i < 6; i++) // 번호 출력
			{
				printf("%2d ", lotto[i]);
			}
			printf("\n");
		}
		for (int i = 0; i < 6; i++)
		{
			lotto[i] = 0;
		}
	}
	return 0;
}

int main()
{
	int n;
	printf("번호를 몇 세트 출력할까요? ");
	scanf_s("%d", &n);
	rand_num(n); // 번호 생성, 출력 함수 호출

	/*
	int lotto[SIZE];
	int loto[6] = { 0 };
	int i, j, n;
	srand(time(NULL));	

	for (i = 0; i < SIZE; i++)
	{
		lotto[i] = (rand() % 45 + 1);
		for (j = 0; j < i; j++)
		{
			if (lotto[i] == lotto[j])
			{
				i--;
			}
		}
	}
	bubbleSort(lotto, SIZE);

	for (i = 0; i < SIZE; i++)
	{
		printf("당첨번호 : %d\n", lotto[i]);
	}
	*/
	return 0;
}