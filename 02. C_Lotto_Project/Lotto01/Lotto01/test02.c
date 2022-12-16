/*
printf("1. rand()\n");
printf("rand : %d\n", rand());
printf("rand : %d\n", rand());

printf("2. rand()와 동일한 시드의 srand()\n");
srand(32323);
printf("rand : %d\n", rand());
srand(32323);
printf("rand : %d\n", rand());
srand(32323);
printf("rand : %d\n", rand());

printf("3. rand()와 4개의 시드 srand()\n");
for (int i = 0; i < 4; ++i)
{
	srand(i);
	printf("rand : %lld\n", rand());
}


printf("%d\n", time(NULL));
*/

#include <stdio.h>
#include <stdlib.h>
#include <time.h>

void SelectionSort(int arr[], int n)
{
    int i, k, p, temp;
    for (i = 0; i < n - 1; i++) {
        p = i;
        for (k = i + 1; k < n; k++) {
            if (arr[k] < arr[p]) p = k; // Ascending sort(오름차순 정렬)
        }
        temp = arr[i];
        arr[i] = arr[p];
        arr[p] = temp;
    }
}

int main()
{
    int  lotto[6] = { 0 };   // 나머지 5개에는 0으로 채움 --> 6개 모두 0으로 초기화 된다.
    int i = 0, n = 0;
    srand((unsigned)time(NULL));  // 매번 다른 수를 생성하도록 랜덤함수 초기화

    while (1)   // 중복수가 존재하기 때문에  for 문으로  6번 반복하면 안됨
    {
        //  rand() % 45 : 0부터 44까지 의 난수를 생성한다.
        //  rand() % 45  + 1 : 1부터 45까지의 난수를 생성한다.

        int r = rand() % 45 + 1;  // 1~45 사이의 랜덤 수 생성, 중복 가능

        for (i = 0; i < n; i++)         // 이미 생성된 개수 만큼만 중복된 수인지 검사한다.
            if (lotto[i] == r) break;     // 이미 생성된 번호인지(중복수) 검사한다.

        if (n == i) lotto[n++] = r;            // 중복수가 아닐때에만 n위치에 생성된 수를 기억시킨다.
        if (n >= 6) break;        // 랜덤 수 6개가 생성되었으면 무한 반복을 벗어난다.
    }

    // 크기순으로 정렬한다.
    SelectionSort(lotto, 6);

    // 생성된 번호 출력한다.
    for (i = 0; i < 6; i++)
        printf("%d\n", lotto[i]);

    return 0;
}