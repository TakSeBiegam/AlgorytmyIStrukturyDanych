import java.util.Arrays;
import java.util.Random;

public class SortowanieArrays {
    public static void main(String args[]) {
        int wielkoscTablicy = 100000;
        int przebiegiDlaSredniej = 100;
        int[] tablica = new int[wielkoscTablicy];
        Random rand = new Random();
        long before;
        for (int j = 0; j < przebiegiDlaSredniej; j++) {
            for (int i = 0; i < wielkoscTablicy; i++) {
                tablica[i] = rand.nextInt();
            }
            before = System.currentTimeMillis();
            Arrays.sort(tablica);
            System.out.println(System.currentTimeMillis() - before);
        }
    }
}
